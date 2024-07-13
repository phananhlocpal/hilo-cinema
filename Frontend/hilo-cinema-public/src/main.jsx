import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import './index.css'
import { legacy_createStore as createStore, applyMiddleware} from 'redux';
import { Provider } from "react-redux";
import { allReducers } from "./redux/reducers/index.js"
import { thunk } from 'redux-thunk';

const store = createStore(allReducers, applyMiddleware(thunk));

ReactDOM.createRoot(document.getElementById('root')).render(
  <Provider store={store}>
    <React.StrictMode>
      <App />
    </React.StrictMode>,
  </Provider>

)