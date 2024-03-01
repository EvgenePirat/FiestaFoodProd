import { useState } from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { MainLayout } from '../layouts';

export default function Routing() {
  const [isAuth, setIsAuth] = useState(false);

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<MainLayout setIsAuth={setIsAuth} />}>
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
