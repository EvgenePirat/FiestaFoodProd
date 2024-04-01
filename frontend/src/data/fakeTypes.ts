import burgerImg from '../assets/images/types/burger.png';
import meatImg from '../assets/images/types/meat.png';
import drinkImg from '../assets/images/types/drink.png';
import saladImg from '../assets/images/types/salad.png';
import snacksImg from '../assets/images/types/snacks.png';
import kebabImg from '../assets/images/types/kebab.png';

import { CategoryType } from '../types/CategoryType.ts';

const types: CategoryType[] = [
  {
    id: 1,
    categoryName: 'Бургери',
    photoPaths: burgerImg
  },
  {
    id: 2,
    categoryName: 'М`ясо',
    photoPaths: meatImg
  },
  {
    id: 3,
    categoryName: 'Напої',
    photoPaths: drinkImg
  },
  {
    id: 4,
    categoryName: 'Салати',
    photoPaths: saladImg
  },
  {
    id: 5,
    categoryName: 'Картопля',
    photoPaths: snacksImg
  },
  {
    id: 6,
    categoryName: 'Шаурма',
    photoPaths: kebabImg
  }
];

export { types };
