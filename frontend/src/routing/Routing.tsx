import { useSelector } from 'react-redux';
import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom';
import { RootState } from '../redux/store';
import { MainLayout } from '../layouts';
import { AuthPage, CreateOrderPage } from '../pages';
import { routeCreateOrder } from '../data/routes';

export default function Routing() {
  const isAuth = useSelector((state: RootState) => state.authSlice.isAuth);

  return (
    <BrowserRouter>
      <Routes>
        {isAuth ? (
          <Route path="/" element={<MainLayout />}>
            <Route path={`/${routeCreateOrder}/:type?`} element={<CreateOrderPage />} />
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
