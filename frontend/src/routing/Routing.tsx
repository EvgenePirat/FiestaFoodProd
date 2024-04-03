import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom';
import { useSelector } from 'react-redux';
import { RootState } from '../redux/store';

import { routeCreateOrder, routeInventory, routeMenu, routeOrders } from '../data/routes';

import { MainLayout } from '../layouts';
import { AuthPage, CreateOrderPage, OrdersPage } from '../pages';

export default function Routing() {
  const isAuth = useSelector((state: RootState) => state.authSlice.isAuth);

  return (
    <BrowserRouter>
      <Routes>
        {isAuth ? (
          <Route path="/" element={<MainLayout />}>
            <Route path={`/${routeCreateOrder}/:type?`} element={<CreateOrderPage />} />
            <Route path={`/${routeOrders}`} element={<OrdersPage />} />
            <Route path={`/${routeInventory}`} element={<Navigate to={`/${routeCreateOrder}`} />} />
            <Route path={`/${routeMenu}`} element={<Navigate to={`/${routeCreateOrder}`} />} />
            <Route path="/*?" element={<Navigate to={`/${routeCreateOrder}`} />} />
          </Route>
        ) : (
          <>
            <Route path="/auth" element={<AuthPage />} />
            <Route path="/*?" element={<Navigate to="/auth" />} />
          </>
        )}
      </Routes>
    </BrowserRouter>
  );
}
