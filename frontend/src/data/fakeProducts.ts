import burgerImg1 from '../assets/images/products/burgers-1.png';
import burgerImg2 from '../assets/images/products/burgers-2.png';
import drinkImg1 from '../assets/images/products/drinks-1.png';
import drinkImg2 from '../assets/images/products/drinks-2.png';
import drinkImg3 from '../assets/images/products/drinks-3.png';
import kebabImg1 from '../assets/images/products/kebab-1.png';
import kebabImg2 from '../assets/images/products/kebab-2.png';
import meatImg1 from '../assets/images/products/meat-1.png';
import meatImg2 from '../assets/images/products/meat-2.png';
import meatImg3 from '../assets/images/products/meat-3.png';
import potatoImg1 from '../assets/images/products/potatoes-1.png';
import potatoImg2 from '../assets/images/products/potatoes-2.png';
import potatoImg3 from '../assets/images/products/potatoes-3.png';
import saladImg1 from '../assets/images/products/salads-1.png';

import { DishType } from '../types/DishType.ts';

const products: DishType[] = [
  {
    id: 1,
    title: 'Burger 1',
    image: burgerImg1,
    categoryId: 1,
    price: 100,
    dishIngredients: [
      {
        ingredientId: 1,
        count: 5
      }
    ]
  },
  {
    id: 2,
    title: 'Burger 2',
    image: burgerImg2,
    categoryId: 1,
    price: 150,
    dishIngredients: [
      {
        ingredientId: 1,
        count: 5
      }
    ]
  },
  {
    id: 3,
    title: 'Drink 1',
    image: drinkImg1,
    categoryId: 3,
    price: 100,
    dishIngredients: [
      {
        ingredientId: 1,
        count: 5
      }
    ]
  },
  {
    id: 4,
    title: 'Drink 2',
    image: drinkImg2,
    categoryId: 3,
    price: 300,
    dishIngredients: [
      {
        ingredientId: 1,
        count: 5
      }
    ]
  },
  {
    id: 5,
    title: 'Drink 3',
    image: drinkImg3,
    categoryId: 3,
    price: 200,
    dishIngredients: [
      {
        ingredientId: 1,
        count: 5
      }
    ]
  },
  {
    id: 6,
    title: 'Kebab 1',
    image: kebabImg1,
    categoryId: 6,
    price: 600,
    dishIngredients: [
      {
        ingredientId: 1,
        count: 5
      }
    ]
  },
  {
    id: 7,
    title: 'Kebab 2',
    image: kebabImg2,
    categoryId: 6,
    price: 400,
    dishIngredients: [
      {
        ingredientId: 1,
        count: 5
      }
    ]
  },
  {
    id: 8,
    title: 'Meat 1',
    image: meatImg1,
    categoryId: 2,
    price: 100,
    dishIngredients: [
      {
        ingredientId: 1,
        count: 5
      }
    ]
  },
  {
    id: 9,
    title: 'Meat 2',
    image: meatImg2,
    categoryId: 2,
    price: 200,
    dishIngredients: [
      {
        ingredientId: 1,
        count: 5
      }
    ]
  },
  {
    id: 10,
    title: 'Meat 3',
    image: meatImg3,
    categoryId: 2,
    price: 300,
    dishIngredients: [
      {
        ingredientId: 1,
        count: 5
      }
    ]
  },
  {
    id: 11,
    title: 'Potatoes 1',
    image: potatoImg1,
    categoryId: 5,
    price: 150,
    dishIngredients: [
      {
        ingredientId: 1,
        count: 5
      }
    ]
  },
  {
    id: 12,
    title: 'Potatoes 2',
    image: potatoImg2,
    categoryId: 5,
    price: 200,
    dishIngredients: [
      {
        ingredientId: 1,
        count: 5
      }
    ]
  },
  {
    id: 13,
    title: 'Potatoes 3',
    image: potatoImg3,
    categoryId: 5,
    price: 300,
    dishIngredients: [
      {
        ingredientId: 1,
        count: 5
      }
    ]
  },
  {
    id: 14,
    title: 'Salads 1',
    image: saladImg1,
    categoryId: 4,
    price: 400,
    dishIngredients: [
      {
        ingredientId: 1,
        count: 5
      }
    ]
  }
];

export { products };
