import styles from './DishCard.module.scss';

interface DishCardProps {
  title: string;
  image: string;
  onClick?: () => void;
}

export default function DishCard({ title, image, onClick }: DishCardProps) {
  return (
    <li className={styles['card']} onClick={onClick}>
      <div className={styles['image-block']}>
        <img className={styles['image']} src={image} alt={title} />
      </div>
      <p className={styles['title']}>{title}</p>
    </li>
  );
}
