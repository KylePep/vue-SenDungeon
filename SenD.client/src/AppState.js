import { reactive } from 'vue'
import { extractIdentifiers } from "vue/compiler-sfc"

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  /** @type {import('./models/Account.js').Account{}} */
  activeProfile: {},
  userActivity: '',
  edit: false,
  screenWidth: 0
})
