import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';

import { DishType } from '../types/DishType.ts';
import { CategoryType } from '../types/CategoryType.ts';

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

export const loadDishes = createAsyncThunk('dish/loadDishes', async () => {
  const response = await axios.dish.getAllDish();
  return response.data;
});

const dishesSlice = createSlice({
  name: 'dishes',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    //loadCategories
    builder.addCase(loadCategories.fulfilled, (state, action) => {
      state.categories = action.payload;
    });

    //loadDishes
    builder.addCase(loadDishes.fulfilled, (state, action) => {
      state.dishes = action.payload;
    });
  }
});

// export const {} = dishesSlice.actions;
export default dishesSlice.reducer;
