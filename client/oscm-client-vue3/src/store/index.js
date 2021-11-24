import { createApp } from "vue";
import Vuex from 'vuex';

const app = createApp();
app.use(Vuex);

const store = new Vuex.Store({
    modules: {
      app,
      settings,
      user
    },
    getters
  })
  
  export default store