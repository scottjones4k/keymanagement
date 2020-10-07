import apiService from './ApiService';
import { KeySet } from '../models/Keys';

class KeyService {

    async createKeySet(id: string): Promise<KeySet> {
        const response = await apiService.post(`api/KeySets`, { Id: id });
        const result = (await response.json()) as KeySet;
        return result;
    }

    async requestKeySets(page: number): Promise<KeySet[]> {
        const response = await apiService.fetch(`api/KeySets?page=${page}`);
        const result = (await response.json()) as KeySet[];
        return result;
    }

    async searchKeySets(searchString: string): Promise<KeySet[]> {
        const response = await apiService.fetch(`api/KeySets?searchstring=${searchString}`);
        const result = (await response.json()) as KeySet[];
        return result;
    }
}

const keyService = new KeyService();

export default keyService;