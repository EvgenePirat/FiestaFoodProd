import { useCallback, useState } from 'react';
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { signIn } from '../../redux/authSlice.ts';
import { phoneMask, phonePlaceholder } from '../../data/masks.ts';

import { Input, InputWithMask } from '../../components';

import styles from './AuthPage.module.scss';

export default function AuthPage() {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const [phoneNumber, setPhoneNumber] = useState('');
  const [password, setPassword] = useState('');

  const handleAuth = useCallback(() => {
    //TODO: Make request to post auth data
    console.log('Submit auth data');

    navigate('/');
    dispatch(signIn());

    setPhoneNumber('');
    setPassword('');
  }, [dispatch, navigate]);

  return (
    <div className={styles['container']}>
      <div className={styles['auth']}>
        <h1 className={styles['h1']}>Авторизація</h1>
        <div className={styles['input-block']}>
          <label className={styles['label']}>Номер телефону:</label>
          <InputWithMask
            type="tel"
            value={phoneNumber}
            onChange={(e) => setPhoneNumber(e.target.value)}
            mask={phoneMask}
            placeholder={phonePlaceholder}
            required
          />
        </div>
        <div className={styles['input-block']}>
          <label className={styles['label']}>Пароль:</label>
          <Input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>
        <button className={styles['login']} onClick={() => handleAuth()}>
          Увійти
        </button>
      </div>
    </div>
  );
}
