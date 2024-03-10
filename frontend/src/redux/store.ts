import { combineReducers, configureStore } from '@reduxjs/toolkit';
import authSlice from './authSlice';
import ordersSlice from './ordersSlice';

const reducer = combineReducers({
  authSlice,
  ordersSlice
});

export const setupStore = (preloadedState?: RootState) => {
  return configureStore({
    reducer,
    preloadedState
  });
};

export type RootState = ReturnType<typeof reducer>;
export type AppStore = ReturnType<typeof setupStore>;
export type AppDispatch = AppStore['dispatch'];
