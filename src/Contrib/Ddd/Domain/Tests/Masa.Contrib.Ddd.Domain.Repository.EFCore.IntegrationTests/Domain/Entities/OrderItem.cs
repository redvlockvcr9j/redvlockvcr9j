// Copyright (c) MASA Stack All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace Masa.Contrib.Ddd.Domain.Repository.EFCore.IntegrationTests.Domain.Entities;

public class OrderItem : Entity<Guid>
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public decimal UnitPrice { get; set; }

    public int Units { get; set; }

    public string PictureUrl { get; set; }

    public Orders Orders { get; set; }
}
