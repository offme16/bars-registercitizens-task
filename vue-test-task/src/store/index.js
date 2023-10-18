import { createStore } from "vuex";
import { listModule } from "@/store/listModule";
export default createStore({
  modules: {
    list: listModule,
  },
});
