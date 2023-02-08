using Castle.DynamicProxy;
using System;


namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }  //metotdan önce
        protected virtual void OnAfter(IInvocation invocation) { } //metotdan sonra
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }  //Hata yakalama anında
        protected virtual void OnSuccess(IInvocation invocation) { } //başarılı olursa
        public override void Intercept(IInvocation invocation) //asıl kullanacağımız metot
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}

