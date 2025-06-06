// Copyright (c) MASA Stack All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

global using IdentityModel.Client;
global using Masa.BuildingBlocks.Authentication.Identity;
global using Masa.BuildingBlocks.Authentication.OpenIdConnect.Models.Constans;
global using Masa.BuildingBlocks.Caching;
global using Masa.BuildingBlocks.Data;
global using Masa.BuildingBlocks.Service.Caller;
global using Masa.BuildingBlocks.StackSdks.Auth;
global using Masa.BuildingBlocks.StackSdks.Auth.Contracts.Consts;
global using Masa.BuildingBlocks.StackSdks.Auth.Contracts.Enum;
global using Masa.BuildingBlocks.StackSdks.Auth.Contracts.Model;
global using Masa.BuildingBlocks.StackSdks.Auth.Service;
global using Masa.BuildingBlocks.StackSdks.Isolation;
global using Masa.Contrib.Caching.Distributed.StackExchangeRedis;
global using Masa.Contrib.StackSdks.Auth;
global using Masa.Contrib.StackSdks.Auth.Model;
global using Masa.Contrib.StackSdks.Auth.Service;
global using Microsoft.Extensions.Configuration;
global using System.Net.Http.Json;
global using System.Text.Json;
global using static Masa.Contrib.StackSdks.Auth.Constants;
