﻿// Copyright (c) MASA Stack All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace Masa.Contrib.Dispatcher.Events.Tests.Middleware;

public class CustomMiddleware<TEvent> : Middleware<TEvent> where TEvent : IEvent
{
    public override Task HandleAsync(TEvent @event, EventHandlerDelegate next)
    {
        if (@event is MiddlewareEvent middlewareEvent)
        {
            middlewareEvent.Results.Add(nameof(CustomMiddleware<TEvent>));
        }
        return next();
    }
}
