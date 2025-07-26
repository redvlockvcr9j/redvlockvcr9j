// Copyright (c) MASA Stack All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace Masa.Contrib.Dispatcher.Events;

public class EventBus : IEventBus
{
    private readonly IServiceProvider _serviceProvider;

    private readonly Internal.Dispatch.Dispatcher _dispatcher;

    private readonly DispatcherOptions _options;

    private IUnitOfWork? _unitOfWork;

    private readonly string LoadEventHelpLink = "https://github.com/masastack/Masa.Contrib/tree/develop/docs/LoadEvent.md";

    public EventBus(IServiceProvider serviceProvider, IOptions<DispatcherOptions> options)
    {
        _serviceProvider = serviceProvider;
        _dispatcher = serviceProvider.GetRequiredService<Internal.Dispatch.Dispatcher>();
        _options = options.Value;
    }

    public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
    {
        ArgumentNullException.ThrowIfNull(@event, nameof(@event));
        var eventType = @event.GetType();

        var middlewares = _serviceProvider.GetRequiredService<IEnumerable<IMiddleware<TEvent>>>();
        if (!_options.UnitOfWorkRelation.ContainsKey(eventType))
        {
            throw new NotSupportedException($"Getting \"{eventType.Name}\" relationship chain failed, see {LoadEventHelpLink} for details. ");
        }

        if (_options.UnitOfWorkRelation[eventType])
        {
            ITransaction transactionEvent = (ITransaction) @event;
            var unitOfWork = _serviceProvider.GetService<IUnitOfWork>();
            if (unitOfWork != null)
            {
                transactionEvent.UnitOfWork = unitOfWork;
                if (_unitOfWork is null)
                {
                    _unitOfWork = transactionEvent.UnitOfWork;
                }
                else
                {
                    middlewares = middlewares.Where(middleware => middleware is not TransactionMiddleware<TEvent>);
                }
            }
        }

        EventHandlerDelegate publishEvent = async () => { await _dispatcher.PublishEventAsync(_serviceProvider, @event); };
        await middlewares.Reverse().Aggregate(publishEvent, (next, middleware) => () => middleware.HandleAsync(@event, next))();
    }

    public IEnumerable<Type> GetAllEventTypes() => _options.AllEventTypes;

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        if (_unitOfWork is null)
            throw new ArgumentNullException("You need to UseUoW when adding services");

        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
