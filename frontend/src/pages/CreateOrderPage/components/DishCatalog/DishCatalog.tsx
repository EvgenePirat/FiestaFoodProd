import { useMemo } from 'react';
import { NavLink, useNavigate, useParams } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from '../../../../redux/store';
import { addItem } from '../../../../redux/ordersSlice';

import { routeCreateOrder } from '../../../../data/routes';

import { DishCard } from '..';

import styles from './DishCatalog.module.scss';

export default function DishCatalog() {
  const types = useSelector((state: RootState) => state.productsSlice.types);
  const dishes = useSelector((state: RootState) => state.productsSlice.products);
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const { type: typeValue } = useParams();

  const type = useMemo(
    () => types.find((obj) => !!typeValue && obj.id === +typeValue),
    [typeValue, types]
  );

  const displayDishes = useMemo(() => {
    if (!typeValue) return [];
    return dishes.filter((obj) => obj.category === +typeValue);
  }, [dishes, typeValue]);

  return (
    <section className={styles['list-container']}>
      <div className={styles['control-block']}>
        {typeValue && (
          <NavLink to={`/${routeCreateOrder}`} className={styles['book-mark']}>
            Повернутись
          </NavLink>
        )}
        <p className={styles['book-mark']}>{type?.categoryName ?? typeValue ?? 'Усі товари'}</p>
      </div>
      <div className={styles['list-block']}>
        {typeValue ? (
          displayDishes.length ? (
            <ul className={styles['list']}>
              {displayDishes.map((obj) => (
                <DishCard key={obj.id} {...obj} onClick={() => dispatch(addItem(obj.id))} />
              ))}
            </ul>
          ) : (
            <p className={styles['empty']}>Каталог порожній</p>
          )
        ) : (
          <ul className={styles['list']}>
            {types.map((obj) => (
              <DishCard
                key={obj.id}
                title={obj.categoryName}
                image={obj.photoPaths}
                onClick={() => navigate(`/${routeCreateOrder}/${obj.id}`)}
              />
            ))}
          </ul>
        )}
      </div>
    </section>
  );
}
