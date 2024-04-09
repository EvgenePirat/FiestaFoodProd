using DataAccess.Data;
using DataAccess.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class DishIngredientRepository : RepositoryBase<DishIngredient>, IDishIngredientRepository
    {
        public DishIngredientRepository(StContext context) : base(context)
        {
        }
    }
}
