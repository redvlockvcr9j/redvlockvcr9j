﻿// Copyright (c) MASA Stack All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace Masa.Contrib.Data.EFCore.Tests.Models;

public class Order : FullAggregateRoot<Guid, Guid?>
{
    public string Name { get; set; }
}
