import React from 'react';
import { getUniversities, filterUniversities } from '../repository/UniversityRepository';
import { University } from '../interfaces/University';
import { UniversitySearch } from '../common/UniversitySearchControl';
import { useSearchParams } from 'react-router-dom';

export const  UniversitiesListPage = () => {
  const [searchParams] = useSearchParams();
  const [universities, setUniversities] = React.useState<University[]>([]);

  const search = searchParams.get('criteria') || '';

  React.useEffect(() => {
    let cancelled = false;
    const doSearch = async (criteria: string) => {
      const foundResults = await filterUniversities(criteria);
      if (!cancelled) {
        setUniversities(foundResults);
      }
    };

    if(search == null || search.trim() === '')
      getUniversities().then((result) => setUniversities(result));
    else doSearch(search);
    
    return () => {
      cancelled = true;
    };
  }, [search]);

    return(
    <div>
      <UniversitySearch></UniversitySearch>
      <ul>
        {universities.map(e => <li key={e.id.toString()}>{e.name}</li>)}
      </ul>
    </div>
    );
};

export default UniversitiesListPage;