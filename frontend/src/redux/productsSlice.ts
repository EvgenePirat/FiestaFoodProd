import { createSlice } from '@reduxjs/toolkit';

import { ProductType, TypeProductType } from '../types/ProductType';

import { types } from '../data/fakeTypes';
import { products } from '../data/fakeProducts';

interface IProductsState {
  products: ProductType[];
  types: TypeProductType[];
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
