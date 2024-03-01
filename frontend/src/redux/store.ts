import { combineReducers, configureStore } from '@reduxjs/toolkit';

const reducer = combineReducers({});

export const setupStore = (preloadedState?: RootState) => {
  return configureStore({
    reducer,
    preloadedState
  });
};

export type RootState = ReturnType<typeof reducer>;
export type AppStore = ReturnType<typeof setupStore>;
export type AppDispatch = AppStore['dispatch'];
