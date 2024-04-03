import { useDispatch } from 'react-redux';
import { useLocation } from 'react-router-dom';
import { signOut } from '../../redux/authSlice';
import { routeCreateOrder, routeOrders, routeInventory, routeMenu } from '../../data/routes.ts';

import { Link } from '../';

import { IoCashOutline } from 'react-icons/io5';
import { BiSolidExit } from 'react-icons/bi';
import { MdDehaze, MdOutlineRestaurantMenu } from 'react-icons/md';
import { LiaClipboardCheckSolid } from 'react-icons/lia';

import styles from './Header.module.scss';

const links = [
  {
    route: `/${routeOrders}`,
    icon: MdDehaze,
    text: 'Усі замовлення'
  },
  {
    route: `/${routeCreateOrder}`,
    icon: IoCashOutline,
    text: 'Каса'
  },
  {
    route: `/${routeInventory}`,
    icon: LiaClipboardCheckSolid,
    text: 'Інвертар'
  },
  {
    route: `/${routeMenu}`,
    icon: MdOutlineRestaurantMenu,
    text: 'Меню'
  }
];

export default function Header() {
  const dispatch = useDispatch();
  const location = useLocation();

  return (
    <header className={styles['header']}>
      <nav className={styles['nav']}>
        <ul className={styles['nav-list']}>
          {links.map((link) => (
            <li className={styles['element']} key={link.route}>
              <Link
                className={`${styles['link']} ${location.pathname.includes(link.route) ? styles['active'] : ''}`}
                to={link.route}>
                <link.icon className={styles['icon']} />
                <span className={styles['link-text']}>{link.text}</span>
              </Link>
            </li>
          ))}
        </ul>
      </nav>

      <button className={styles['user']} onClick={() => dispatch(signOut())}>
        <span className={styles['username']}>Іванов І. І.</span>
        <BiSolidExit className={styles['icon']} />
      </button>
    </header>
  );
}
