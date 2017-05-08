﻿using System;
using System.Collections.Generic;
using System.Linq;

using UmbracoVault.TypeHandlers;

namespace UmbracoVault.Attributes
{
    /// <summary>
    /// Denotes an entity represents an Umbraco Media type.
    /// Exposes the same options as [UmbracoEntity], including AutoMap.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class UmbracoMediaEntityAttribute : UmbracoEntityAttribute
    {
        public override Type TypeHandlerOverride { get; set; } = typeof(MediaTypeHandler);
        //public override Type TypeHandlerOverride
        //{
        //    get
        //    {
        //        return typeof(MediaTypeHandler); 
        //    }
        //    set
        //    {
        //        throw new NotSupportedException("Cannot override type for UmbracoMedia type handler");
        //    }
        //}
    }
}
