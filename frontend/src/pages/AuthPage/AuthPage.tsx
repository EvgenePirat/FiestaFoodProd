import {useCallback, useState} from "react";

import styles from './AuthPage.module.scss';

export default function AuthPage() {
    const [phoneNumber, setPhoneNumber] = useState('');
    const [password, setPassword] = useState('');

    const handleAuth = useCallback(() => {
        //TODO: Make request to post auth data
        console.log("Submit auth data");
    }, []);

    return (
        <div className={styles['container']}>
            <div className={styles['auth']}>
                <h1 className={styles['h1']}>Авторизація</h1>
                <div className={styles['input-block']}>
                    <label className={styles['label']}>Номер телефону:</label>
                    <input type="text" className={styles['input']}
                           onChange={e => setPhoneNumber(e.target.value)} required/>
                </div>
                <div className={styles['input-block']}>
                    <label className={styles['label']}>Пароль:</label>
                    <input type="password" className={styles['input']}
                           onChange={e => setPassword(e.target.value)} required/>
                </div>
                <button className={styles['btn-auth']} onClick={() => handleAuth()}>Увійти</button>
            </div>
        </div>
    );
}
