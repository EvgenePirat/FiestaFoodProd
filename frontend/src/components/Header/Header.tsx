import { BiSolidExit } from 'react-icons/bi';
import { MdDehaze } from 'react-icons/md';
import { NavLink } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import { signOut } from '../../redux/authSlice';

import { Button } from '../';

import styles from './Header.module.scss';

export default function Header() {
  const dispatch = useDispatch();

  return (
    <header className={styles['header']}>
      <nav className={styles['nav']}>
        <ul className={styles['nav-list']}>
          <li className={styles['element']}>
            <NavLink to={'/'} className={styles['link']}>
              <MdDehaze className={styles['icon']} />
              Усі замовлення
            </NavLink>
          </li>
        </ul>
      </nav>

      <Button className={styles['user']} onClick={() => dispatch(signOut())}>
        <span className={styles['username']}>Іванов І. І.</span>
        <BiSolidExit className={styles['icon']} />
      </Button>
    </header>
  );
}
