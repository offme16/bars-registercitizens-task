import axios from "axios";
export const listModule = {
  state: () => ({
    list: [],
    isLoadingList: false,
    page: 1,
    limit: 15,
    totalpages: 0,
  }),
  getters: {},
  mutations: {
    setList(state, list) {
      state.list = list;
    },
    setAdd(state, people) {
      state.list = [people, ...state.list];
    },
    setDel(state, id) {
      state.list = [...state.list.filter((p) => p.id !== id)];
    },
    setChange(state, updatedPost) {
      const postIndex = state.list.findIndex((p) => p.id === updatedPost.id);
      if (postIndex !== -1) {
        state.list[postIndex] = updatedPost;
      }
    },
    setLoading(state, bool) {
      state.isLoadingList = bool;
    },
    setPage(state, page) {
      state.page = page;
    },
    setTotalPages(state, totalPages) {
      state.totalPages = totalPages;
    },
  },
  actions: {
    async fetchList({ state, commit }) {
      try {
        commit("setLoading", true);
        const response = await axios.get("https://localhost:7240/people", {
          params: {
            _page: state.page,
            _limit: state.limit,
          },
        });
        commit(
          "setTotalPages",
          Math.ceil(response.headers["x-total-count"] / state.limit)
        );
        commit("setList", response.data);
      } catch (e) {
        console.log(e);
      } finally {
        commit("setLoading", false);
      }
    },
    async loadMoreList({ state, commit }) {
      try {
        commit("setPage", state.page + 1);
        const response = await axios.get("https://localhost:7240/people", {
          params: {
            _page: state.page,
            _limit: state.limit,
          },
        });

        commit("setList", response.data);
      } catch (e) {
        console.log(e);
      }
    },
    async createPost({ commit }, listData) {
      try {
        const response = await axios.post(
          "https://localhost:7240/people",
          listData
        );

        commit("setAdd", response.data);
      } catch (e) {
        console.error("Ошибка при создании поста", e);
      }
    },
    async deletePost({ commit }, id) {
      try {
        const response = await axios.delete(
          `https://localhost:7240/people?id=${id}`
        );
        commit("setDel", response.data);
      } catch (e) {
        console.error("Ошибка при удалении поста", e);
      }
    },
    async updatePost({ commit }, listData) {
      try {
        const response = await axios.put(
          "https://localhost:7240/people",
          listData
        );
        commit("setChange", response.data);
      } catch (e) {
        console.error("Ошибка при обновлении поста", e);
      }
    },
    async searchPersonPost({ commit }, { fullName, searchValue }) {
      try {
        const response = await axios.get(
          "https://localhost:7240/people/search",
          {
            params: {
              search: fullName, // Первый параметр
              dateStringStart: searchValue.dateStringStart, // Второй параметр
              dateStringEnd: searchValue.dateStringEnd, // Третий параметр
            },
          }
        );
        commit("setList", response.data);
      } catch (e) {
        console.error("Ошибка при поиске поста", e);
      }
    },
  },
};
