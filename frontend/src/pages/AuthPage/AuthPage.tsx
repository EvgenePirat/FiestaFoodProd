import {useCallback, useState} from 'react';
import {useDispatch} from 'react-redux';
import {useNavigate} from 'react-router-dom';
import {signIn} from "../../redux/authSlice.ts";

import {Button, Input} from '../../components';

import styles from './AuthPage.module.scss';

export default function AuthPage() {
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const [phoneNumber, setPhoneNumber] = useState('');
    const [password, setPassword] = useState('');

    const handleAuth = useCallback(() => {
        //TODO: Make request to post auth data
        console.log("Submit auth data");

        navigate('/');
        dispatch(signIn());

        setPhoneNumber('');
        setPassword('');
    }, []);

    return (
        <div className={styles['container']}>
            <div className={styles['auth']}>
                <h1 className={styles['h1']}>Авторизація</h1>
                <div className={styles['input-block']}>
                    <label className={styles['label']}>Номер телефону:</label>
                    <Input type="text" value={phoneNumber}
                           onChange={e => setPhoneNumber(e.target.value)} required/>
                </div>
                <div className={styles['input-block']}>
                    <label className={styles['label']}>Пароль:</label>
                    <Input type="password" value={password}
                           onChange={e => setPassword(e.target.value)} required/>
                </div>
                <Button onClick={() => handleAuth()}>Увійти</Button>
            </div>
        </div>
    );
}
