import { BiSolidExit } from 'react-icons/bi';
import { MdDehaze, MdOutlineBookmarkBorder } from 'react-icons/md';
import { useDispatch } from 'react-redux';
import { signOut } from '../../redux/authSlice';

import { Button, Link } from '../';

import styles from './Header.module.scss';

export default function Header() {
  const dispatch = useDispatch();

  return (
    <header className={styles['header']}>
      <nav className={styles['nav']}>
        <ul className={styles['nav-list']}>
          <li className={styles['element']}>
            <Link to="/">
              <MdDehaze className={styles['icon']} />
              <span>Усі замовлення</span>
            </Link>
          </li>
          <li className={styles['element']}>
            <Link to="/">
              <MdOutlineBookmarkBorder className={styles['icon']} />
              <span>Створення замовлення</span>
            </Link>
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
