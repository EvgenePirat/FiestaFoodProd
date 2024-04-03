import { AsideBar, DishCatalog } from './components';

import styles from './CreateOrderPage.module.scss';

export default function CreateOrderPage() {
  return (
    <div className={styles['page-block']}>
      <AsideBar />
      <DishCatalog />
    </div>
  );
}
