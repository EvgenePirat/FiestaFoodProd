import burgerImg from '../assets/images/burger.png';
import meatImg from '../assets/images/meat.png';
import drinkImg from '../assets/images/drink.png';
import saladImg from '../assets/images/salad.png';
import snacksImg from '../assets/images/snacks.png';
import kebabImg from '../assets/images/kebab.png';

import { ProductCardType } from '../types/ProductCardType';

const products: ProductCardType[] = [
  {
    id: 1,
    title: 'Burgers',
    image: burgerImg
  },
  {
    id: 2,
    title: 'Meat',
    image: meatImg
  },
  {
    id: 3,
    title: 'Drinks',
    image: drinkImg
  },
  {
    id: 4,
    title: 'Salads',
    image: saladImg
  },
  {
    id: 5,
    title: 'Potatoes',
    image: snacksImg
  },
  {
    id: 6,
    title: 'Kebab',
    image: kebabImg
  }
];

export { products };
