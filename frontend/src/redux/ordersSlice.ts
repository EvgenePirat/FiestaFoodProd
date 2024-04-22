import { PayloadAction, createSlice, createAsyncThunk } from '@reduxjs/toolkit';

import { OrderItemType } from '../types/OrderItemType';
import { OrderType } from '../types/OrderType';

import axios from '../api/axios';

interface IOrdersState {
  orderItems: OrderItemType[];
  orders: OrderType[];
}

const initialState: IOrdersState = {
  orderItems: [],
  orders: []
};

export const loadOrders = createAsyncThunk('order/loadOrders', async () => {
  const response = await axios.order.getAllOrder();
  return response.data;
});

export const createOrder = createAsyncThunk(
  'order/createOrder',
  async (payload: Pick<OrderType, 'orderDetail' | 'orderItems'>) => {
    const response = await axios.order.postOrder(payload);
    return response.data;
  }
);

export const changeOrderStatus = createAsyncThunk(
  'order/changeOrderStatus',
  async ({
    id,
    payload
  }: {
    id: OrderType['id'];
    payload: Parameters<typeof axios.order.putOrder>[1];
  }) => {
    const response = await axios.order.putOrder(id, payload);
    return response.data;
  }
);

const ordersSlice = createSlice({
  name: 'orders',
  initialState,
  reducers: {
    addItem: (state, action: PayloadAction<OrderItemType['dishId']>) => {
      if (state.orderItems.every((obj) => obj.dishId !== action.payload)) {
        state.orderItems.push({ dishId: action.payload, count: 1, comment: '' });
      }
    },
    removeItem: (state, action: PayloadAction<OrderItemType['dishId']>) => {
      state.orderItems = state.orderItems.filter((obj) => obj.dishId !== action.payload);
    },
    changeCount: (
      state,
      action: PayloadAction<{ id: OrderItemType['dishId']; value: OrderItemType['count'] }>
    ) => {
      const item = state.orderItems.find((obj) => obj.dishId === action.payload.id);
      if (item) item.count = action.payload.value;
    },
    changeComment: (
      state,
      action: PayloadAction<{ id: OrderItemType['dishId']; value: OrderItemType['comment'] }>
    ) => {
      const item = state.orderItems.find((obj) => obj.dishId === action.payload.id);
      if (item) item.comment = action.payload.value;
    },
    clearOrder: (state) => {
      state.orderItems = [];
    }
  },
  extraReducers: (builder) => {
    //loadOrders
    builder.addCase(loadOrders.fulfilled, (state, action) => {
      state.orders = action.payload.orders;
    });

    //createOrder
    builder.addCase(createOrder.fulfilled, (state, action) => {
      state.orderItems = [];
      state.orders.push(action.payload);
    });

    //changeOrderStatus
    builder.addCase(changeOrderStatus.fulfilled, (state, action) => {
      const idx = state.orders.findIndex((order) => order.id === action.payload.id);
      if (idx >= 0) state.orders[idx] = action.payload;
    });
  }
});

export const { addItem, removeItem, changeCount, changeComment, clearOrder } = ordersSlice.actions;
export default ordersSlice.reducer;
