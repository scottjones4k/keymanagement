import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import KeySet from './components/KeySet';
import NewKeySet from './components/NewKeySet';

import './custom.css'

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/newkeyset' component={NewKeySet} />
        <Route path='/keysets/:page?' component={KeySet} />
    </Layout>
);
