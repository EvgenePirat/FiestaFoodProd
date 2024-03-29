import instance from './instance.ts';
import category from './category.ts';
import user from './user.ts';
import order from './order.ts';

export default {
  category: category(instance),
  user: user(instance),
  order: order(instance)
};
