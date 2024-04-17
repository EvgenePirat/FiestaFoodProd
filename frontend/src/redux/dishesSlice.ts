import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';

import { DishType } from '../types/DishType.ts';
import { CategoryType } from '../types/CategoryType.ts';

import { products } from '../data/fakeProducts';
import axios from '../api/axios';

interface IDishesState {
  dishes: DishType[];
  categories: CategoryType[];
}

const initialState: IDishesState = {
  dishes: [],
  categories: []
};

export const loadCategories = createAsyncThunk('dish/loadCategories', async () => {
  const response = await axios.category.getAllCategory();
  return response.data;
});

const dishesSlice = createSlice({
  name: 'dishes',
  initialState,
  reducers: {
    loadDishes: (state) => {
      state.dishes = products;
    }
  },
  extraReducers: (builder) => {
    //loadCategories
    builder.addCase(loadCategories.fulfilled, (state, action) => {
      state.categories = action.payload;
    });
  }
});

export const { loadDishes } = dishesSlice.actions;
export default dishesSlice.reducer;
