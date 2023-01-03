using Business.Abstract;
using Business.Constans;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        ICartDal _cartDal;
        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public IResult Add(Cart cart)
        {
            _cartDal.Add(cart);
            return new SuccessResult(CartMessages.Added);
        }

        public IResult Delete(Cart cart)
        {
            _cartDal.Add(cart);
            return new SuccessResult(CartMessages.Deleted);
        }

        public IDataResult<Cart> GetById(int id)
        {
            return new SuccessDataResult<Cart>(_cartDal.Get(p => p.ProductId == id));
        }

        public IDataResult<List<Cart>> GetList()
        {
            return new SuccessDataResult<List<Cart>>(_cartDal.GetAll());
        }

        public IResult Update(Cart cart)
        {
            _cartDal.Add(cart);
            return new SuccessResult(CartMessages.Updated);
        }
    }
}

