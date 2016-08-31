﻿// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 13/Jul/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.API;

namespace Framework.Data.API
{
    public interface IPartialModel : ICommon
    {
        void CreateModel(object dataContext);
    }
}