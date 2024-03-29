import { PayloadAction, createSlice } from '@reduxjs/toolkit';

import { OrderItemType } from '../types/OrderItemType';
import { OrderType } from '../types/OrderType';

interface IOrdersState {
  order: OrderItemType[];
  orders: OrderType[];
}

const initialState: IOrdersState = {
  order: [],
  orders: []
};

const ordersSlice = createSlice({
  name: 'orders',
  initialState,
  reducers: {
    addItem: (state, action: PayloadAction<OrderItemType['id']>) => {
      if (state.order.every((obj) => obj.id !== action.payload)) {
        state.order.push({ id: action.payload, count: 1, comment: '' });
      }
    },
    removeItem: (state, action: PayloadAction<OrderItemType['id']>) => {
      state.order = state.order.filter((obj) => obj.id !== action.payload);
    },
    changeCount: (
      state,
      action: PayloadAction<{ id: OrderItemType['id']; value: OrderItemType['count'] }>
    ) => {
      const item = state.order.find((obj) => obj.id === action.payload.id);
      if (item) item.count = action.payload.value;
    },
    changeComment: (
      state,
      action: PayloadAction<{ id: OrderItemType['id']; value: OrderItemType['comment'] }>
    ) => {
      const item = state.order.find((obj) => obj.id === action.payload.id);
      if (item) item.comment = action.payload.value;
    },
    clearOrder: (state) => {
      state.order = [];
    },
    createOrder: (
      state,
      action: PayloadAction<Pick<OrderType, 'finalSum' | 'payment' | 'entryValue' | 'restValue'>>
    ) => {
      const date = Date.now();
      state.orders.push({ id: date, date, list: state.order, ...action.payload });
      state.order = [];
    }
  }
});

export const { addItem, removeItem, changeCount, changeComment, clearOrder, createOrder } =
  ordersSlice.actions;
export default ordersSlice.reducer;
