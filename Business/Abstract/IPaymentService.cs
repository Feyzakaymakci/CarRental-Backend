using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult Pay(Payment payment);
        IResult Add(Payment payment);
        IResult Delete(Payment payment);
        IResult Update(Payment payment);
        IDataResult<Payment> GetById(int id);
        IDataResult<List<Payment>> GetAll();
        IDataResult<List<Payment>> GetAllByCustomerId(int customerId);
      
    }
}
