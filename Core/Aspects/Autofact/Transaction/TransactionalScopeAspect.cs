using Castle.DynamicProxy;
using Core.Utilities.Interceptors.FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Aspects.Autofact.Transaction
{
   public class TransactionalScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope scope=new TransactionScope() )
            {
                try
                {
                    invocation.Proceed();
                    scope.Complete();
                }
                catch (System.Exception )
                {
                    scope.Dispose();
                    throw;
                }
            }
        }
    }
}
