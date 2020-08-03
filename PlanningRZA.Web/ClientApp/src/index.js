import 'bootstrap/dist/css/bootstrap.min.css'
import React, {Component} from 'react';
import ReactDOM from 'react-dom';
import Layout from 'containers/layout';
import Objects from 'containers/objects';
import {createStore, applyMiddleware} from 'redux'
import {composeWithDevTools} from 'redux-devtools-extension'
import thunk from 'redux-thunk'
import createRootReducer from 'reducers'
import {Provider} from 'react-redux'
import {BrowserRouter, Route, Switch} from 'react-router-dom'
import { createBrowserHistory } from 'history';
import { syncHistoryWithStore  } from 'react-router-redux';
import { ConnectedRouter } from 'connected-react-router'

const AppRoute = ({ component: Component, layout: Layout, ...rest }) => (
  <Route {...rest} render={props => (
    <Layout>
      <Component {...props} />
    </Layout>
  )} />
)

const history = createBrowserHistory()
const store = createStore(
  createRootReducer(history),
  composeWithDevTools(
    applyMiddleware(thunk)
  )
)

ReactDOM.render(
  <Provider store={store}>
    <ConnectedRouter history ={history}>
      <Switch>
        <AppRoute path='/' layout={Layout} component={Objects}/>
      </Switch>
  </ConnectedRouter>
  </Provider>,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
//serviceWorker.unregister();
