import {useSelector} from 'react-redux';
import {BrowserRouter, Navigate, Route, Routes} from 'react-router-dom';
import {RootState} from '../redux/store';
import {MainLayout} from '../layouts';
import {AuthPage} from '../pages';

export default function Routing() {
    const isAuth = useSelector((state: RootState) => state.authSlice.isAuth);

    return (
        <BrowserRouter>
            <Routes>
                {isAuth ? (
                    <Route path="/" element={<MainLayout/>}>
                        <Route path="/" element={<h1>No Auth</h1>}/>
                    </Route>
                ) : (
                    <>
                        <Route path="/" element={<Navigate to="/auth"/>}/>
                        <Route path="/auth" element={<AuthPage/>}/>
                    </>
                )}
            </Routes>
        </BrowserRouter>
    );
}
