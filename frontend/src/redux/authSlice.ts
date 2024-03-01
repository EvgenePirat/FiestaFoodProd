import { createSlice } from '@reduxjs/toolkit';

interface IAuthState {
  isAuth: boolean;
}

const initialState: IAuthState = {
  isAuth: false
};

const authSlice = createSlice({
  name: 'collections',
  initialState,
  reducers: {
    signIn: (state) => {
      state.isAuth = true;
    },
    signOut: (state) => {
      state.isAuth = false;
    }
  }
});

export const { signIn, signOut } = authSlice.actions;
export default authSlice.reducer;
