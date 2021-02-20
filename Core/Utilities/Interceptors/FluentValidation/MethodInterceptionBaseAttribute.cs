﻿using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors.FluentValidation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple =true, Inherited =true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }
        public virtual void Intercept(IInvocation invocation)
        {
            
        }
    }
}
