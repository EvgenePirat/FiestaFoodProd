import { createSlice } from '@reduxjs/toolkit';

import { DishType } from '../types/DishType.ts';
import { CategoryType } from '../types/CategoryType.ts';

import { types } from '../data/fakeTypes';
import { products } from '../data/fakeProducts';

interface IProductsState {
  products: DishType[];
  types: CategoryType[];
}

const initialState: IProductsState = {
  products: [],
  types: []
};

const productsSlice = createSlice({
  name: 'products',
  initialState,
  reducers: {
    loadTypes: (state) => {
      state.types = types;
    },
    loadProducts: (state) => {
      state.products = products;
    }
  }
});

export const { loadTypes, loadProducts } = productsSlice.actions;
export default productsSlice.reducer;
