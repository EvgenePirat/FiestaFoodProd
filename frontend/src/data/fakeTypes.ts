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
    title: 'Бургери',
    image: burgerImg
  },
  {
    id: 2,
    title: 'М`ясо',
    image: meatImg
  },
  {
    id: 3,
    title: 'Напої',
    image: drinkImg
  },
  {
    id: 4,
    title: 'Салати',
    image: saladImg
  },
  {
    id: 5,
    title: 'Картопля',
    image: snacksImg
  },
  {
    id: 6,
    title: 'Шаурма',
    image: kebabImg
  }
];

export { types };
