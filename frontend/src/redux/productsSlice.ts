import { createSlice } from '@reduxjs/toolkit';
import { ProductType } from '../types/ProductCardType';
import { products } from '../data/fakeProducts';

interface IAuthState {
  products: ProductType[];
}

const initialState: IAuthState = {
  products: []
};

const productsSlice = createSlice({
  name: 'products',
  initialState,
  reducers: {
    loadProducts: (state) => {
      state.products = products;
    }
  }
});

export const { loadProducts } = productsSlice.actions;
export default productsSlice.reducer;
