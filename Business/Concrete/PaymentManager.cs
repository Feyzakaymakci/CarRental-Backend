using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        } 

        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.PaymentInformationSaved);
        }

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult(Messages.PaymentDeleted);
        }

        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult(Messages.PaymentUpdated);
        }

        public IResult Pay(Payment payment)
        {
            return new SuccessResult(Messages.PaymentSuccessful);
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll()); 
        }

        public IDataResult<List<Payment>> GetAllByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(p => p.CustomerId == customerId));
        }

        public IDataResult<Payment> GetByPaymentId(int id)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(p => p.PaymentId == id));
        }
    }
}
