using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concreate
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialdal;

        public TestimonialManager(ITestimonialDal testimonialdal)
        {
            _testimonialdal = testimonialdal;
        }

        public void TCreate(Testimonial entity)
        {
            _testimonialdal.Create(entity);
        }

        public void TDelete(int id)
        {
            _testimonialdal.Delete(id);
        }

        public List<Testimonial> TGetAll()
        {
            return _testimonialdal.GetAll();
        }

        public Testimonial TGetById(int id)
        {
            return _testimonialdal.GetById(id);
        }

        public void TUpdate(Testimonial entity)
        {
            _testimonialdal.Update(entity);
        }
    }
}
