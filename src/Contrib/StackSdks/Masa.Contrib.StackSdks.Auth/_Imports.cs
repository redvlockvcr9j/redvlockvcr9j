// Copyright (c) MASA Stack All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

global using Masa.BuildingBlocks.Authentication.Identity;
global using Masa.BuildingBlocks.Service.Caller;
global using Masa.BuildingBlocks.Service.Caller.Options;
global using Masa.BuildingBlocks.StackSdks.Auth;
global using Masa.BuildingBlocks.StackSdks.Auth.Contracts.Consts;
global using Masa.BuildingBlocks.StackSdks.Auth.Contracts.Model;
global using Masa.BuildingBlocks.StackSdks.Auth.Contracts.Provider;
global using Masa.BuildingBlocks.StackSdks.Auth.Service;
global using Masa.Contrib.Service.Caller;
global using Masa.Contrib.Service.Caller.HttpClient;
global using Masa.Contrib.StackSdks.Auth;
global using Microsoft.AspNetCore.Http;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using System.Net.Http.Headers;
global using System.Text.Json;
global using static Masa.Contrib.StackSdks.Auth.Constants;
