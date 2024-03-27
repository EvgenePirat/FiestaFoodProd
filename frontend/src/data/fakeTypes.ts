import burgerImg from '../assets/images/types/burger.png';
import meatImg from '../assets/images/types/meat.png';
import drinkImg from '../assets/images/types/drink.png';
import saladImg from '../assets/images/types/salad.png';
import snacksImg from '../assets/images/types/snacks.png';
import kebabImg from '../assets/images/types/kebab.png';

import { TypeProductType } from '../types/ProductType';

const types: TypeProductType[] = [
  {
    id: 'burgers',
    title: 'Бургери',
    image: burgerImg
  },
  {
    id: 'meat',
    title: 'М`ясо',
    image: meatImg
  },
  {
    id: 'drinks',
    title: 'Напої',
    image: drinkImg
  },
  {
    id: 'salads',
    title: 'Салати',
    image: saladImg
  },
  {
    id: 'potatoes',
    title: 'Картопля',
    image: snacksImg
  },
  {
    id: 'kebab',
    title: 'Шаурма',
    image: kebabImg
  }
];

export { types };
