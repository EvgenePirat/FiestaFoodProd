import { useSelector } from 'react-redux';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { RootState } from '../redux/store';
import { MainLayout } from '../layouts';

export default function Routing() {
  const isAuth = useSelector((state: RootState) => state.authSlice.isAuth);

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<MainLayout />}>
          {isAuth ? (
            <Route path="/" element={<h1>Auth</h1>} />
          ) : (
            <Route path="/" element={<h1>No Auth</h1>} />
          )}
        </Route>
      </Routes>
    </BrowserRouter>
  );
}
