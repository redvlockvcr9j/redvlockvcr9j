// Copyright (c) MASA Stack All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

[assembly: InternalsVisibleTo("Masa.Contrib.BasicAbility.Tsc.Tests")]
namespace Masa.Contrib.BasicAbility.Tsc;

internal class TscClient : ITscClient
{
    public TscClient(ICaller caller)
    {
        LogService = new LogService(caller);
        MetricService = new MetricService(caller);
    }

    public ILogService LogService { get; }

    public IMetricService MetricService { get; }
}
