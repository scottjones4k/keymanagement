import { Action, Reducer } from 'redux';
import { AppThunkAction } from './';
import keyService from '../services/KeyService';
import _ from 'lodash';
import { KeySet } from '../models/Keys';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface KeyState {
    isLoading: boolean;
    keySets?: KeySet[];
    page: number;
    searchString?: string;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface CreateKeySetAction {
    type: 'CREATE_KEY_SET';
}

interface CreatedKeySetAction {
    type: 'CREATED_KEY_SET';
}

interface RequestKeySetsAction {
    type: 'REQUEST_KEY_SETS';
    page: number;
}

interface ReceiveKeySetsAction {
    type: 'RECEIVE_KEY_SETS';
    page: number;
    keySets: KeySet[];
}

interface SearchKeySetsAction {
    type: 'SEARCH_KEY_SETS';
    searchString: string;
}

interface SearchedKeySetsAction {
    type: 'SEARCHED_KEY_SETS';
    searchString: string;
    keySets: KeySet[];
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = CreateKeySetAction | CreatedKeySetAction | RequestKeySetsAction | ReceiveKeySetsAction | SearchKeySetsAction | SearchedKeySetsAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    createKeySet: (id: string): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        const appState = getState();
        if (appState && appState.key && !appState.key.isLoading) {
            keyService.createKeySet(id)
                .then(data => {
                    dispatch({ type: 'CREATED_KEY_SET' });
                });

            dispatch({ type: 'CREATE_KEY_SET' });
        }
    },
    requestKeySets: (page: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        const appState = getState();
        if (appState && appState.key && !appState.key.isLoading && appState.key.page !== page) {
            keyService.requestKeySets(page)
                .then(data => {
                    dispatch({ type: 'RECEIVE_KEY_SETS', page: page, keySets: data });
                });

            dispatch({ type: 'REQUEST_KEY_SETS', page: page });
        }
    },
    searchKeySets: (search: string): AppThunkAction<KnownAction> => (dispatch, getState) => {
        const appState = getState();
        if (appState && appState.key && appState.key.searchString !== search) {
            keyService.searchKeySets(search)
                .then(data => {
                    dispatch({ type: 'SEARCHED_KEY_SETS', searchString: search, keySets: data });
                });
            dispatch({ type: 'SEARCH_KEY_SETS', searchString: search });
        }
    },
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: KeyState = { isLoading: false, page: -1 };

export const reducer: Reducer<KeyState> = (state: KeyState | undefined, incomingAction: Action): KeyState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'CREATE_KEY_SET':
            return _.assign({}, state, {
                isLoading: true
            });
        case 'CREATED_KEY_SET':
            return _.assign({}, state, {
                isLoading: false
            });
        case 'REQUEST_KEY_SETS':
            return _.assign({}, state, {
                isLoading: true,
                page: action.page
            });
        case 'RECEIVE_KEY_SETS':
            if (state.isLoading && state.page === action.page) {
                return _.assign({}, state, {
                    isLoading: false,
                    keySets: action.keySets
                });
            };
            return state;
        case 'SEARCH_KEY_SETS':
            return _.assign({}, state, {
                isLoading: true,
                searchString: action.searchString
            });
        case 'SEARCHED_KEY_SETS':
            if (state.isLoading && state.searchString === action.searchString) {
                return _.assign({}, state, {
                    isLoading: false,
                    keySets: action.keySets
                });
            };
            return state;
    }

    return state;
};