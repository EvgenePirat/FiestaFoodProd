import { AxiosInstance } from 'axios';

export default function (instance: AxiosInstance) {
  return {
    getUserById(id: number) {
      return console.log('Get user by id');
    },

    getUserAll(pageSize?: number, pageNumber?: number) {
      return console.log('Get all users');
    },

    getUserByQuery(pageSize?: number, pageNumber?: number) {
      return console.log('Get user query');
    },

    postUser(login: string, password: string) {
      return console.log('Post user');
    },

    putUser(id: number, login: string, role: string) {
      return console.log('Put user');
    },

    deleteUser(id: number) {
      return console.log('Delete user by id');
    }
  };
}
